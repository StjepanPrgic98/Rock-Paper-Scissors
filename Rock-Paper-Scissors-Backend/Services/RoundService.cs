using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Rock_Paper_Scissors_Backend.Entities;
using Rock_Paper_Scissors_Backend.Interfaces.IServices;
using SQLitePCL;

namespace Rock_Paper_Scissors_Backend.Services
{
    public class RoundService : IRoundService
    {
        public Round CreateRound(string playerMove)
        {
            Round round = new Round
            {
                PlayerMove = playerMove,
                PcMove = GeneratePcMove(),
            };

            round.Result = DecideWinner(round.PlayerMove, round.PcMove);

            return round;
        }

        public bool CheckIfPlayerMoveIsValid(string playerMove)
        {
            if(playerMove != "rock" && playerMove != "paper" && playerMove != "scissors")
            {
                return false;
            }
            return true;
        }

        private string GeneratePcMove()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 4);

            if(randomNumber == 1){return "rock";}
            if(randomNumber == 2){return "paper";}
            if(randomNumber == 3){return "scissors";}

            else{return "rock";} //This should never happen, but just in case
        }

        private string DecideWinner(string playerMove, string pcMove)
        {
            if (playerMove == pcMove)
            {
                return "Draw";
            }
            else if ((playerMove == "rock" && pcMove == "scissors") ||
                    (playerMove == "paper" && pcMove == "rock") ||
                    (playerMove == "scissors" && pcMove == "paper"))
            {
                return "Victory";
            }
            else
            {
                return "Loss";
            }
        }
    }
}