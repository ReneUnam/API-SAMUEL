using WebApi.Model;

namespace WebApi.Interface;

public interface ICultivoService
{
    public IEnumerable<CultivoEntities> GetAll();
    public CultivoEntities GetById(int id);
    public CultivoEntities Add(CultivoEntities cultivo);
    void Update(CultivoEntities cultivo);
    void Delete(int id);
}
