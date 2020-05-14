import ProjectModels.Oficiu;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

import java.util.Date;
import java.util.List;

public class test {


    public static void main(String[] args) {
        initialize();
        test t = new test();
        t.addMessage();
        t.getMessages();
        close();
    }

     void getMessages(){
        try(Session session = sessionFactory.openSession()) {
            Transaction tx = null;
            try {
                tx = session.beginTransaction();
                List<Oficiu> messages =
                        session.createQuery("from Oficiu as m order by m.usarname asc", Oficiu.class).
                                //  setFirstResult(1).setMaxResults(5).
                                        list();
                System.out.println(messages.size() + " message(s) found:");
                for (Oficiu m : messages) {
                    System.out.println(m.toString());
                }
                tx.commit();
            } catch (RuntimeException ex) {
                if (tx != null)
                    tx.rollback();
            }
        }

    }

     void addMessage(){
        try(Session session = sessionFactory.openSession()) {
            Transaction tx = null;
            try {
                tx = session.beginTransaction();
                Oficiu of= new Oficiu("SAdddddd","sadas");
                session.save(of);
                tx.commit();
            } catch (RuntimeException ex) {
                if (tx != null)
                    tx.rollback();
            }
        }
    }

    static SessionFactory sessionFactory;
    static void initialize() {

        final StandardServiceRegistry registry = new StandardServiceRegistryBuilder()
                .configure() // configures settings from hibernate.cfg.xml
                .build();
        try {
            sessionFactory = new MetadataSources( registry ).buildMetadata().buildSessionFactory();
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            e.printStackTrace();

            StandardServiceRegistryBuilder.destroy( registry );
        }
    }

    static void close(){
        if ( sessionFactory != null ) {
            sessionFactory.close();
        }

    }
}
