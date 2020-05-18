package RepositoryInterfaces;

import ProjectModels.Oficiu;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public interface IOficiiREpository {
    public boolean logIn(Oficiu of);
}
