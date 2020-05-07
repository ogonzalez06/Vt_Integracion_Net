﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/pais")]
    [ApiController]
    public class PaisController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public PaisController (ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return context.Paises.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pais = context.Paises.FirstOrDefault(x => x.Id == id);
            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }

    }
}