using System;
using Woww.DAL.DAO;
using Woww.DAL.DTO;

namespace Woww
{
    class Program
    {
        static void Main(string[] args)
        {
            //TeamDAO teamDAO = new TeamDAO();

            //#region Création de team
            //Team t1 = new Team();
            //t1.Name = "WAD 21";

            //Team t2 = new Team();
            //t2.Name = "Games";

            //if (teamDAO.Create(t1)) Console.WriteLine("Team 1 créée");
            //else Console.WriteLine("Un problème est survenu");

            //if (teamDAO.Create(t2)) Console.WriteLine("Team 2 créée");
            //else Console.WriteLine("Un problème est survenu");
            //#endregion

            //foreach (Team t in teamDAO.GetAll())
            //{
            //    Console.WriteLine("ID : {0} -- Nom : {1}", t.Id, t.Name);
            //}

            PlayerDAO playerDAO = new PlayerDAO();

            //Player newP = new Player();
            //newP.Name = "steve";
            //newP.Email = "steve@test.com";
            //newP.Password = "1234";
            //newP.FK_Team = 1;

            //if (playerDAO.Register(newP)) Console.WriteLine("Inscription réussie");
            //else Console.WriteLine("ça à foiré quelque part");

            Player currentPlayer = playerDAO.Login("steve@test.com", "1234");

            if (currentPlayer != null)
            { 
                Console.WriteLine("Bonjour {0}", currentPlayer.Name);
                Console.WriteLine("Mot de passe : {0}", currentPlayer.Password);
                Console.WriteLine("Equipe : {0}", currentPlayer.FK_Team);
            }
            else Console.WriteLine("Erreur de mot de passe ou d'adresse email");

        }
    }
}
