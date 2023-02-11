using MySql.Data.MySqlClient;
using TheGreatesrApplication.DataBasesServices;
using TheGreatesrApplication.Models;

namespace TheGreatesrApplication.Services.Repository
{
    public class ASkillRepository : IASkillRepository
    {
        public int Create(ASkills item)
        {
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO animal_skill(idanimal, idskill) 
                                        VALUES(@idanimal, @idskill)";
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = item.AnimalId;
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = item.SkilId;
            return command.ExecuteNonQuery();
        }

        public int Update(ASkills item)
        {
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE animal_skill SET 
                                    idskill = @idskill
                                    WHERE idanimal_skill = @idanimal_skill";
            command.Parameters.Add("@idanimal_skill", MySqlDbType.Int32).Value = item.AnimalSkillId;
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = item.AnimalId;
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = item.SkilId;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM animal_skill WHERE idanimal_skill=@idanimal_skill";
            command.Parameters.Add("@idanimal_skill", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<ASkills> GetAll()
        {
            List<ASkills> list = new();
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal_skill";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ASkills animalSkill = new()
                {
                    AnimalSkillId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    SkilId = reader.GetInt32(2),
                };
                list.Add(animalSkill);
            }
            return list;
        }

        public IList<ASkills> GetAllByAnimalId(int id)
        {
            List<ASkills> list = new();
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal_skill WHERE idanimal=@idanimal";
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ASkills animalSkill = new()
                {
                    AnimalSkillId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    SkilId = reader.GetInt32(2),
                };
                list.Add(animalSkill);
            }
            return list;
        }

        public IList<ASkills> GetAllBySkillId(int id)
        {
            List<ASkills> list = new();
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal_skill WHERE idskill=@idskill";
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ASkills animalSkill = new()
                {
                    AnimalSkillId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    SkilId = reader.GetInt32(2),
                };
                list.Add(animalSkill);
            }
            return list;
        }

        public ASkills GetById(int id)
        {
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal_skill WHERE idanimal_skill=@idanimal_skill";
            command.Parameters.Add("@idanimal_skill", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ASkills animalSkill = new()
                {
                    AnimalSkillId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    SkilId = reader.GetInt32(2),
                };
                return animalSkill;
            }
            else
            {
                return null;
            }
        }
    }
}
