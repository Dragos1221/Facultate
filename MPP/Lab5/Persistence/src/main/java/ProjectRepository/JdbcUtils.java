package ProjectRepository;

import java.io.FileInputStream;
import java.io.FileReader;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

public class JdbcUtils {
    private Properties jdbcProp;
    private static final Logger logger = LogManager.getLogger();
    public JdbcUtils(){
        Properties prop =new Properties();
        try {
            prop.load(new FileInputStream("C:\\Users\\Dragos\\Desktop\\FacultateInfo\\MPP\\Lab3_2\\ClientFX\\src\\main\\resources\\baza.properties"));
            System.out.println("Properties set. ");
            prop.list(System.out);
        } catch (IOException e) {
            System.out.println("Cannot find bd.config "+e);
        }
        jdbcProp=prop;
    }
    private Connection instance=null;
    private Connection getNewConnection() {
        logger.traceEntry();
        String url=jdbcProp.getProperty("ceva.jdbc.url");
        String user=jdbcProp.getProperty("tasks.jdbc.user");
        String pass=jdbcProp.getProperty("tasks.jdbc.pass");
        logger.info("trying to connect to database ... {}",url);
        logger.info("user: {}",user);
        logger.info("pass: {}", pass);
        Connection con=null;
        try {
            if (user!=null && pass!=null)
                con= DriverManager.getConnection(url,user,pass);
            else
                con=DriverManager.getConnection(url);
        } catch (SQLException e) {
            logger.error(e);
            System.out.println("Error getting connection "+e);
        }
        return con;
    }

    public Connection getConnection(){
        logger.traceEntry();
        try {
            if (instance==null || instance.isClosed())
                instance=getNewConnection();

        } catch (SQLException e) {
            logger.error(e);
            System.out.println("Error DB "+e);
        }
        logger.traceExit(instance);
        return instance;
    }
}
