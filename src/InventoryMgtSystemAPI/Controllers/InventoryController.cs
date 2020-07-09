using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using InventoryMgtSystemAPI.Models;
using InventoryMgtSystemAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMgtSystemAPI.Controllers {
    [ApiController]
    [Route ("api/{controller}")]
    public class InventoryController : ControllerBase {
        private readonly IInventoryRepo _inventoryRepo;

        public InventoryController (IInventoryRepo inventoryRepo) {
            _inventoryRepo = inventoryRepo;
        }

        //GET api/controller
        [HttpGet]
        public ActionResult<IEnumerable<InventoryModel>> GetAllInventory () {
            var inventory = _inventoryRepo.GetInventories ();
            if (inventory is null) {
                return BadRequest ();
            }

            return Ok (inventory);
        }

        //GET api/controller/{id}
        [HttpGet ("{id}", Name = "GetInventoryById")]
        public ActionResult<InventoryModel> GetInventoryById (int id) {
            try 
            {
                var inventory = _inventoryRepo.GetInventoryById (id);
                if (inventory is null) {
                    return NotFound ();
                }
                return Ok (inventory);
            } catch (Exception e) 
            {
                return NotFound(e.Message);
            }
        }

        //CREATE api/controller
        [HttpPost]
        public ActionResult CreateInventory (InventoryModel model) 
        {
            if (model is null) 
            {
                return NotFound ();
            }
            _inventoryRepo.CreateInventory (model);
            _inventoryRepo.SaveChanges ();

            return CreatedAtRoute (nameof (GetInventoryById), new { Id = model.InventoryId }, model);
        }

        //DELETE api/controller/{id}
        [HttpDelete ("{id}")]
        public ActionResult DeleteInventory (int id) 
        {
            _inventoryRepo.DeleteInventory (id);
            _inventoryRepo.SaveChanges ();
            return NoContent ();
        }

        //PUT api/controller/{id}
        [HttpPut("{id}")]
        public ActionResult<InventoryModel> UpdateInventory(int id, InventoryModel model)
        {
            try
            {
                _inventoryRepo.UpdateInventory(id, model);
                _inventoryRepo.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // //PATCH api/controller/{id}
        // [HttpPatch("{id}")]
        // public ActionResult<InventoryModel> PartialUpdateInventory()

    }
}