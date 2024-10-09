using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApi.Interface;
using WebApi.Model;

namespace WebApi.Implementation;

public class CultivoService : ICultivoService
{
    public IEnumerable<CultivoEntities> GetAll()
    {
        throw new NotImplementedException();
    }
    public CultivoEntities GetById(int id)
    {
        throw new NotImplementedException();
    }
    public CultivoEntities Add(CultivoEntities cultivo)
    {
        throw new NotImplementedException();
    }

    public void Update(CultivoEntities cultivo)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

}
