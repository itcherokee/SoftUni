namespace TheSlum.GameEngine
{
    using System;
    using Characters;
    using Items;

    public class NewEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "add":
                    this.AddItem(inputParams);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character = null;
            int coordinateX = int.Parse(inputParams[3]);
            int coordinateY = int.Parse(inputParams[4]);
            var team = (Team)Enum.Parse(typeof(Team), inputParams[5]);
            switch (inputParams[1])
            {
                case "warrior":
                    character = new Warrior(inputParams[2], coordinateX, coordinateY, team);
                    break;
                case "mage":
                    character = new Mage(inputParams[2], coordinateX, coordinateY, team);
                    break;
                case "healer":
                    character = new Healer(inputParams[2], coordinateX, coordinateY, team);
                    break;
                default:
                    break;
            }

            characterList.Add(character);
        }

        protected new void AddItem(string[] inputParams)
        {
            Item item = null;
            switch (inputParams[2])
            {
                case "axe":
                    item = new Axe(inputParams[3]);
                    break;
                case "shield":
                    item = new Shield(inputParams[3]);
                    break;
                case "injection":
                    item = new Injection(inputParams[3]);
                    break;
                case "pill":
                    item = new Pill(inputParams[3]);
                    break;
                default:
                    break;
            }

            var character = this.GetCharacterById(inputParams[1]);
            character.AddToInventory(item);
        }
    }
}
