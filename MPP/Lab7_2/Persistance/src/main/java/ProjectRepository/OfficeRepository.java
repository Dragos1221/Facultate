package ProjectRepository;



import ProjectModels.Oficiu;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;


public class OfficeRepository {
    private static final Logger logger= LogManager.getLogger();
    JdbcUtils jdbc;

    public OfficeRepository(JdbcUtils jdbc) {
        this.jdbc = jdbc;
    }


    public boolean logIn(Oficiu of){
        String query="SELECT OficiiTabel.User , Password FROM OficiiTabel";
        Connection con = jdbc.getConnection();
        try(Statement stm = con.createStatement()){
            try(ResultSet res = stm.executeQuery(query)){
                    while(res.next())
                    {
                        if(res.getString("User").equals(of.getUsarname())
                                && res.getString("Password").equals(of.getPassword()))
                        {
                            return true;
                        }
                    }
            }
            catch (SQLException e) {
                e.printStackTrace();
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }
}
