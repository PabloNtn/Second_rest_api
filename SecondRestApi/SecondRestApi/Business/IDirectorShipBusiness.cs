using SecondRestApi.Model;
using System.Collections.Generic;

namespace SecondRestApi.Business
{
    public interface IDirectorShipBusiness
    {
        List<DirectorShip> FindAll();
        DirectorShip Create(DirectorShip director);
        void Delete(long id);
    }
}
