﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using R3Use.Core.Entities;
using R3Use.Core.Repository.Contracts;
using R3Use.Web.Models;

namespace R3Use.Web.Controllers
{

    [Route("api/[controller]")]
    public class AssignmentsController : Controller
    {
        private readonly IAdapter _adapter;
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentsController(IAdapter adapter, IAssignmentRepository assignmentRepository)
        {
            _adapter = adapter;
            _assignmentRepository = assignmentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var assignments = await _assignmentRepository.AllAsync();

            return Ok(_adapter.Adapt<IList<Assignment>>(assignments));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _assignmentRepository.DeleteAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AssignmentModel assignment)
        {
            if (ModelState.IsValid)
            {
                var a = _adapter.Adapt<Assignment>(assignment);

                await _assignmentRepository.AddAsync(a);

                return Created("/", a.Id);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AssignmentModel assignmentModel)
        {

            if (ModelState.IsValid)
            {
                var assignment = await _assignmentRepository.GetAsync(id);

                if (assignment == null)
                    return NotFound(id);


                assignment.Name = assignmentModel.Name;

                await _assignmentRepository.UpdateAsync(assignment);


            }

            return Ok();
        }
     }
}