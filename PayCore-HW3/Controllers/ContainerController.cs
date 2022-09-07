using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCore_HW3.Context;
using PayCore_HW3.Context.Abstract;
using PayCore_HW3.Extensions;
using PayCore_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore_HW3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IMapperSession<Container> session;
       
        public ContainerController(IMapperSession<Container> session)
        {
            this.session = session;
            
        }
        [HttpGet]
        public List<Container> Get() // Container listesini döner
        {
            List<Container> result = session.Entities.ToList();
            return result;
        }
        [HttpGet("{vehicleid}")] // container listesini vehicleid'ye göre döner
        public IActionResult GetByVehicleId(int vehicleid)
        {
            List<Container> container = session.Entities.Where(x => x.VehicleId == vehicleid).ToList();
            if(container.Count==0 || container == null)
            {
                return NotFound();
            }
            return Ok(container);
        }
        [HttpGet("{vehicleid},{n}")] // vehicleid listesini n girdisi kadar parçalayıp kümeleyip response eden action metot
        public IActionResult GetByNContainer(int vehicleid,int n)
        {
            
            List<Container> container = session.Entities.Where(x => x.VehicleId == vehicleid).ToList();
            
            IEnumerable<IEnumerable<Container>> partitions = container.Split(n); // extension metot
           
            return Ok(partitions);

        }
        [HttpPost]
        public void Post([FromBody] Container container) // veritabanına container nesnesini ekler
        {
            try
            {
                session.BeginTranstaction();
                session.Save(container);
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
        public ActionResult<Container> Put([FromBody] UpdateContainerModel request) // updatecontainermodeline göre veritabanında nesneyi günceller.

        {
            Container container = session.Entities.FirstOrDefault(x => x.Id == request.Id);

            if (container == null)
            {
                return NotFound();
            }
            try
            {
                // Vehicleid güncellenmez
                session.BeginTranstaction();
                container.ContainerName = request.ContainerName;
                container.Latitude = request.Latitude;
                container.Longitude = request.Longitude;
                session.Update(container);
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
        public IActionResult Delete(int id) // Container nesnesi veritabanından silinir
        {
            Container container = session.Entities.Where(x => x.Id == id).SingleOrDefault();
            

            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTranstaction();
                session.Delete(container);
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

    }
}
