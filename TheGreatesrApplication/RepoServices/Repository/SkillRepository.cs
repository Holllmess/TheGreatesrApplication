using MySql.Data.MySqlClient;
using TheGreatesrApplication.DataBasesServices;
using TheGreatesrApplication.Models;

namespace TheGreatesrApplication.Services.Repository
{
    public class SkillRepository : ISkillRepository
    {
        public int Create(Skills item)
        {
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO skill(idkind_of_animal, skill) 
                                        VALUES(@idkind_of_animal, @skill)";
            command.Parameters.Add("@idkind_of_animal", MySqlDbType.Int32).Value = item.AnimalKindId;
            command.Parameters.Add("@skill", MySqlDbType.VarChar).Value = item.CharacterSkill;
            return command.ExecuteNonQuery();
        }

        public int Update(Skills item)
        {
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE skill SET 
                                    skill = @skill
                                    WHERE idskill = @idskill";
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = item.SkillId;
            command.Parameters.Add("@skill", MySqlDbType.VarChar).Value = item.CharacterSkill;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM skill WHERE idskill=@idskill";
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<Skills> GetAll()
        {
            List<Skills> list = new();
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM skill";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Skills skill = new()
                {
                    SkillId = reader.GetInt32(0),
                    AnimalKindId = reader.GetInt32(1),
                    CharacterSkill = reader.GetString(2),
                };
                list.Add(skill);
            }
            return list;
        }

        public IList<Skills> GetAllByAnimalKindId(int id)
        {
            List<Skills> list = new();
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM skill WHERE idkind_of_animal=@idkind_of_animal";
            command.Parameters.Add("@idkind_of_animal", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Skills skill = new()
                {
                    SkillId = reader.GetInt32(0),
                    AnimalKindId = reader.GetInt32(1),
                    CharacterSkill = reader.GetString(2),
                };
                list.Add(skill);
            }
            return list;
        }

        public Skills GetById(int id)
        {
            using MySqlConnection connection = new DataBaseSQL().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM skill WHERE idskill=@idskill";
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Skills skill = new()
                {
                    SkillId = reader.GetInt32(0),
                    AnimalKindId = reader.GetInt32(1),
                    CharacterSkill = reader.GetString(2),
                };
                return skill;
            }
            else
            {
                return null;
            }
        }
    }
}
