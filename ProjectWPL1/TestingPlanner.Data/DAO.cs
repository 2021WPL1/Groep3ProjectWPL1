using System;
using System.Collections.Generic;
using System.Text;
using TestingPlanner.Models;

namespace TestingPlanner.Data
{
    public class DAO
    {//
        // SINGLETON PATTERN
        // We only want one instance of this class through the whole project.
        //
        private static readonly DAO instance = new DAO();

        public static DAO Instance()
        {
            return instance;
        }

        // Private constructor!
        private DAO()
        {
            this.context = new Barco2021Context();
        }

        // DBContext
        private Barco2021Context context;

        /*
         * ZOOS
         */
        public List<Zoo> getAllZoos()
        {
            return context.Zoos.Include(z => z.ZooAnimals).ToList();
        }
        public Zoo addZoo(string location)
        {
            Zoo zoo = new Zoo
            {
                Location = location
            };
            context.Zoos.Add(zoo);
            saveChanges();
            return zoo;
        }
        public Zoo getZooWithId(int id)
        {
            return context.Zoos.Include(z => z.ZooAnimals).FirstOrDefault(z => z.Id == id);
        }
        public void removeZoo(int id)
        {
            context.Zoos.Remove(getZooWithId(id));
            saveChanges();
        }

        /*
         * ANIMALS
         */
        public List<Animal> getAllAnimals()
        {
            return context.Animals.ToList();
        }
        public Animal getAnimalWithId(int id)
        {
            return context.Animals.FirstOrDefault(a => a.Id == id);
        }
        public Animal addAnimal(string name)
        {
            Animal animal = new Animal
            {
                Name = name
            };
            context.Animals.Add(animal);
            saveChanges();
            return animal;
        }
        public void removeAnimal(int id)
        {
            context.Animals.Remove(getAnimalWithId(id));
            saveChanges();
        }

        /*
         * RELATIONS
         */
        public List<Animal> getAnimalsInZoo(int zooId)
        {
            var animals = new List<Animal>();
            var zoo = getZooWithId(zooId);

            foreach (ZooAnimal zooAnimal in zoo.ZooAnimals)
            {
                var animal = context.Animals.FirstOrDefault(a => a.Id == zooAnimal.AnimalId);
                animals.Add(animal);
            }
            return animals;
        }

        public void addAnimalToZoo(int animalId, int zooId)
        {
            Zoo zoo = getZooWithId(zooId);
            zoo.ZooAnimals.Add(new ZooAnimal { AnimalId = animalId });
            saveChanges();
        }

        public void removeAnimalFromZoo(int animalId, int zooId)
        {
            ZooAnimal zooAnimalToRemove = context.ZooAnimals.
                FirstOrDefault(za => za.AnimalId == animalId &&
                                     za.ZooId == zooId);

            context.ZooAnimals.Remove(zooAnimalToRemove);

            saveChanges();
        }

        public void saveChanges()
        {
            context.SaveChanges();
        }
    }
}
