using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CretaceousClient.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public static List<Animal> GetAnimals()
        {
            var apiCall = ApiHelper.GetAnimals();
            var response = apiCall.Result;

            JArray jsonObject = JsonConvert.DeserializeObject<JArray>(response);
            List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(jsonObject.ToString());
            return animals;
        }

        public static Animal GetDetails(int id)
        {
            var apiCall = ApiHelper.Get(id);
            var response = apiCall.Result;
            
            JObject jsonObject = JsonConvert.DeserializeObject<JObject>(response);
            Animal animal = JsonConvert.DeserializeObject<Animal>(jsonObject.ToString());
            return animal;
        }

        public static void AddAnimal(Animal animal)
        {
            string anim = JsonConvert.SerializeObject(animal);
            var apiCallTask = ApiHelper.Post(anim);
        }

        public static void UpdateAnimal(Animal animal)
        {
            string anim = JsonConvert.SerializeObject(animal);
            var apiCallTask = ApiHelper.Put(anim , animal.AnimalId);
        }

        public static void DeleteAnimal(int id)
        {
            var apiCallTask = ApiHelper.Delete(id);
        }
    }
}