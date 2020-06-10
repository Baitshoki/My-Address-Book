﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddressBookWebAPI.Models;

namespace AddressBookWebAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBooksController : ControllerBase
    {
        private readonly AddressBookContext _context;

        public AddressBooksController(AddressBookContext context)
        {
            _context = context;
        }

        // GET: api/AddressBooks
        [HttpGet]       
        public async Task<ActionResult<IEnumerable<AddressBook>>> GetaddressBooks()
        {
            return await _context.addressBooks.ToListAsync();
        }

        // GET: api/AddressBooks/

        [HttpGet]   
        [Route("[action]/{id}")]
        public async Task<ActionResult<AddressBook>> GetAddressBookByID(int id)
        {
            var addressBook = await _context.addressBooks.FindAsync(id);

            if (addressBook == null)
            {
                return NotFound();
            }

            return addressBook;
        }


        //// GET: api/GetAddressBookByFirstName/
        [HttpGet] 
        [Route("[action]/{firstname}")]
        public async Task<ActionResult<AddressBook>> GetAddressBookByFirstName(string firstName)
        {
            var addressBook = await _context.addressBooks.FindAsync(firstName);

            if (addressBook == null)
            {
                return NotFound();
            }

            return addressBook;
        }



        // GET: api/GetAddressBookBySurname/
        [Route("[action]/{surname}")]
        public async Task<ActionResult<AddressBook>> GetAddressBookBySurname(string surname)
        {
            var addressBook = await _context.addressBooks.FindAsync(surname);

            if (addressBook == null)
            {
                return NotFound();
            }

            return addressBook;
        }




        // PUT: api/AddressBooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressBook(int id, AddressBook addressBook)
        {
            if (id != addressBook.ID)
            {
                return BadRequest();
            }

            _context.Entry(addressBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressBookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AddressBooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AddressBook>> PostAddressBook(AddressBook addressBook)
        {
            _context.addressBooks.Add(addressBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressBook", new { id = addressBook.ID }, addressBook);
        }

        // DELETE: api/AddressBooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressBook>> DeleteAddressBook(int id)
        {
            var addressBook = await _context.addressBooks.FindAsync(id);
            if (addressBook == null)
            {
                return NotFound();
            }

            _context.addressBooks.Remove(addressBook);
            await _context.SaveChangesAsync();

            return addressBook;
        }

        private bool AddressBookExists(int id)
        {
            return _context.addressBooks.Any(e => e.ID == id);
        }
    }
}
