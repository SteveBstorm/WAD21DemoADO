using System;
using Woww.DAL.DAO;
using Woww.DAL.DTO;

namespace Woww
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamDAO teamDAO = new TeamDAO();

            #region Création de team
            //Team t1 = new Team();
            //t1.Name = "WAD 21";

            //Team t2 = new Team();
            //t2.Name = "Games";

            //if (teamDAO.Create(t1)) Console.WriteLine("Team 1 créée");
            //else Console.WriteLine("Un problème est survenu");

            //if (teamDAO.Create(t2)) Console.WriteLine("Team 2 créée");
            //else Console.WriteLine("Un problème est survenu"); 
            #endregion

            foreach (Team t in teamDAO.GetAll())
            {
                Console.WriteLine("ID : {0} -- Nom : {1}", t.Id, t.Name);
            }


        }
    }
}
