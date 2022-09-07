using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCore_HW3.Context;
using PayCore_HW3.Context.Abstract;
using PayCore_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore_HW3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapperSession<Vehicle> session;
        private readonly IMapperSession<Container> csession;
        
      
        public VehicleController(IMapperSession<Vehicle> session,IMapperSession<Container> csession)
        {
            this.session = session;
            this.csession = csession;
        }
        [HttpGet]
        public List<Vehicle> Get() // veritabanında kayıtlı araba listesini döndürür
        {
            List<Vehicle> result = session.Entities.ToList();
            return result;
        }
        [HttpPost]
        public void Post([FromBody] Vehicle vehicle) // veritabanına araba ekler
        {
            try
            {
                session.BeginTranstaction();
                session.Save(vehicle);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                session.CloseTransaction();
            }
        }
        [HttpPut] 
        public ActionResult<Vehicle> Put([FromBody] Vehicle request) // veritabanındaki araba nesnesini günceller
        {
            Vehicle vehicle = session.Entities.FirstOrDefault(x => x.Id == request.Id);
            
            if (vehicle == null)
            {
                return NotFound();
            }
            try
            {
                session.BeginTranstaction();

                vehicle.VehicleName = request.VehicleName;
                vehicle.VehiclePlate = request.VehiclePlate;
                session.Update(vehicle);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                session.CloseTransaction();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // veritabanından arabayı siler
        {
            Vehicle vehicle = session.Entities.Where(x => x.Id == id).SingleOrDefault();
            List<Container> container = csession.Entities.Where(x => x.VehicleId == id).ToList();

            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTranstaction();
                session.Delete(vehicle);
                session.Commit();

                csession.BeginTranstaction(); // container için baglantı baslatır
                foreach (var item in container) // eğer araba silinirse arabanın baglı oldugu container listeside silinir
                {
                    csession.Delete(item);
                }
                csession.Commit();

            }
            catch (Exception ex)
            {
                session.Rollback();
                csession.Rollback();
                throw new Exception(ex.Message);
                
            }
            finally
            {
                csession.CloseTransaction();
                session.CloseTransaction();
            
            }

            return Ok();
        }
    }
}
