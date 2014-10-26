using FarmersCreed.Interfaces;
using FarmersCreed.Units;

namespace FarmersCreed.Simulator
{
    class ExtendedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "feed":
                    this.FeedObjectInFarm(inputCommands);
                    break;
                case "water":
                    this.WaterObjectInFarm(inputCommands);
                    break;
                case "exploit":
                    this.ExploiteObjectInFarm(inputCommands);
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                    {
                        var cherry = new CherryTree(id);
                        this.farm.Plants.Add(cherry);
                    }
                    break;
                case "TobaccoPlant":
                    {
                        var tobacco = new TobaccoPlant(id);
                        this.farm.Plants.Add(tobacco);
                    }
                    break;
                case "Cow":
                    {
                        var cow = new Cow(id);
                        this.farm.Animals.Add(cow);
                    }
                    break;
                case "Swine":
                    {
                        var swine = new Swine(id);
                        this.farm.Animals.Add(swine);
                    }
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }

        private void ExploiteObjectInFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];
            //•	exploit animal/plant (animalId/plantId) – exploits (gets the product from) an animal/plant and adds the product to the farm
            this.farm.Exploit()
        }

        private void WaterObjectInFarm(string[] inputCommands)
        {
            string id = inputCommands[1];
            this.farm.Water(this.GetPlantById(id));
        }

        private void FeedObjectInFarm(string[] inputCommands)
        {
            //•	feed (animalId) (foodId) (quantity) – feeds animal animalId with quantity of food foodId and reduces the food's quantity
            string animal = inputCommands[1];
            string product = inputCommands[2];
            string quantity = inputCommands[1];
            this.farm.Feed(this.GetAnimalById(animal),(IEdible)GetProductById(product), int.Parse(quantity));
        }
    }
}