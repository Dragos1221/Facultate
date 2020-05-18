package RepositoryInterfaces;

import ProjectModels.Rezervare;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public interface IRezervareREpository {
    public List<Rezervare> getList(int idDestinatie);

    public boolean save(Rezervare rez);
}
