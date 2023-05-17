using Microsoft.AspNetCore.Mvc;
using CRUD.Models;
using Services.Interfaces;
using System.Text;

namespace backend_dotnet.Controllers;

[ApiController]
[Route("/students")]
public class InfoController : ControllerBase
{
    private readonly ILogger<InfoController> _logger;
    private readonly IGenericServices<Infostudent> _infoServices;


    public InfoController(ILogger<InfoController> logger, IGenericServices<Infostudent> infoServices)
    {
        _logger = logger;
        _infoServices = infoServices;
    }

    [HttpGet]
    public async Task<IEnumerable<Infostudent>> GetAll()
    {
        try {
            return await _infoServices.GetAll();
        }catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<Infostudent?> Get(int id)
    {
        try {
            return await _infoServices.Get(id);
        }catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
    [HttpPost]
    public async Task<Infostudent?> Add([FromBody] Infostudent student)
    {
        try {
            return await _infoServices.Add(student);
        }catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
    [HttpPut]
    public async Task<Infostudent?> Update([FromBody] Infostudent student)
    {
        try {
            return await _infoServices.Update(student);
        }catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<Infostudent?> Delete(int id)
    {
        try {
            return await _infoServices.Delete(id);
        }catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
}
