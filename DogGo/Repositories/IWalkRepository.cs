using System.Collections.Generic;
using DogGo.Models;
using Microsoft.Data.SqlClient;


namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetAllWalks();
        Walk GetWalkById(int id);
        void UpdateWalk(Walk walk);
        void AddWalk(Walk walk);
        void DeleteWalk(int id);
        List<Walk> GetWalksByWalkerId(int ownerId);
    }
}
