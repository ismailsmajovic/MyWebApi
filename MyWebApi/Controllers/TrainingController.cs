using System;
using System.Collections.Generic;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    public class TrainingController
    {
        private List<Training> trainings;

        public TrainingController()
        {
            trainings = new List<Training>();
        }

        public void AddTraining(Training training)
        {
            trainings.Add(training);
        }

        public void RemoveTraining(Training training)
        {
            trainings.Remove(training);
        }

        public List<Training> GetAllTrainings()
        {
            return trainings;
        }
    }
}
