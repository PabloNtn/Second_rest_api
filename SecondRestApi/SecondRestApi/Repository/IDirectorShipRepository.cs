using Microsoft.AspNetCore.Mvc;
using SecondRestApi.Model;
using System.Collections.Generic;

namespace SecondRestApi.Business
{
    public interface IDirectorShipRepository
    {
       DirectorShip FindByUserName(string username, string password);
        List<DirectorShip> FindAll();
        ActionResult<DirectorShip> Create(DirectorShip director);
        ActionResult<int> Delete(long id);
    }
}
