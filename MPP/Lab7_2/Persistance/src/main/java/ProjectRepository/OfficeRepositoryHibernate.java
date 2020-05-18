package ProjectRepository;



import ProjectModels.Oficiu;
import RepositoryInterfaces.IOficiiREpository;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;


public class OfficeRepositoryHibernate implements IOficiiREpository {
    private static final Logger logger = LogManager.getLogger();
    JdbcUtils jdbc;

    public OfficeRepositoryHibernate(JdbcUtils jdbc) {
        this.jdbc = jdbc;
    }


    public boolean logIn(Oficiu of) {
        initialize();
        try (Session session = sessionFactory.openSession()) {
            Transaction t = null;
            try {
                t = session.beginTransaction();
                List<Oficiu> list =
                        session.createQuery("from Oficiu  as m order by m.usarname asc", Oficiu.class).list();
                for (Oficiu m : list) {
                    if (m.getUsarname().equals(of.getUsarname())) {
                        return true;
                    }
                }
                t.commit();
            } catch (RuntimeException ex) {
                if (t!= null) t.rollback();
                return false;
            }
            return false;
        }finally {
            close();
        }
    }

    static SessionFactory sessionFactory;

    void initialize() {

        final StandardServiceRegistry registry = new StandardServiceRegistryBuilder()
                .configure()
                .build();
        try {
            sessionFactory = new MetadataSources(registry).buildMetadata().buildSessionFactory();
        } catch (Exception e) {
            System.out.println(e.getMessage());
            e.printStackTrace();
            StandardServiceRegistryBuilder.destroy(registry);
        }
    }

    void close() {
        if (sessionFactory != null) {
            sessionFactory.close();
        }
    }
}
