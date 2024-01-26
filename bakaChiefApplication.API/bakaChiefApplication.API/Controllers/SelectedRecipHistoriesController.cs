﻿using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Controllers;

public class SelectedRecipHistoriesController : ODataController
{
    private readonly DatabaseContext _databaseContext;

    public SelectedRecipHistoriesController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [EnableQuery]
    public ActionResult<IAsyncEnumerable<SelectedRecipHistory>> Get() => Ok(_databaseContext.SelectedRecipHistories);

    [EnableQuery]
    public async Task<ActionResult<SelectedRecipHistory>> GetAsync([FromRoute] string key)
    {
        var selectedRecipHistory = await _databaseContext.SelectedRecipHistories.FirstOrDefaultAsync(n => n.Id == key);

        if (selectedRecipHistory == null)
        {
            return NotFound();
        }

        return Ok(selectedRecipHistory);
    }

    public async Task<ActionResult> PostAsync()
    {
        var recips = _databaseContext.Recips.Take(7);

        var selectedRecipHistory = new SelectedRecipHistory {
            Recips = recips.ToHashSet()
        };

        _databaseContext.SelectedRecipHistories.Add(selectedRecipHistory);

        await _databaseContext.SaveChangesAsync();

        return Created(selectedRecipHistory);
    }    
}