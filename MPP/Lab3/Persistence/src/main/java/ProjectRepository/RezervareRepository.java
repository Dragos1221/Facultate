package ProjectRepository;


import ProjectModel.Rezervare;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class RezervareRepository {
    private static final Logger logger= LogManager.getLogger();
    private JdbcUtils jdbc;

    public RezervareRepository(JdbcUtils jdbc) {
        this.jdbc = jdbc;
    }

    public List<Rezervare> getList(int idDestinatie)
    {
        List<Rezervare> list=new ArrayList<>();
        String query="SELECT * From Rezervari Where Rezervari.idDestinatie='"+idDestinatie+"'";
        Connection con = jdbc.getConnection();
        try(Statement stm = con.createStatement()) {
            try (ResultSet res = stm.executeQuery(query)) {
                    while(res.next())
                    {
                        list.add(new Rezervare(res.getInt("idDestinatie"),res.getInt("nrLocuri"),res.getString("Nume")));
                    }
                }
            }catch (SQLException e) {
            e.printStackTrace();
        }
        return list;
    }

    public boolean save(Rezervare rez)
    {
        String query="INSERT into Rezervari(idDestinatie, nrLocuri, Nume ) values ("+rez.getIdDestinatie()+","+rez.getLocuri_rezervate()+",'"+rez.getNume()+"');";
        Connection con = jdbc.getConnection();
        try(Statement stm = con.createStatement()) {
            stm.executeUpdate(query);
                    return true;
        }catch (SQLException e) {
            e.printStackTrace();
        }
    return false;
    }
}
