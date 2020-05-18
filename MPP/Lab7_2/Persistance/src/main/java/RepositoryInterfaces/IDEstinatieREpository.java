package RepositoryInterfaces;

import ProjectModels.Destinatie;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public interface IDEstinatieREpository {
    public int getIdDestinatie(String destinatie , LocalDateTime data);


    public List<Destinatie> returnList();

    public Destinatie getDestinatie(int idDest);

    public void update(Destinatie dest);
}
