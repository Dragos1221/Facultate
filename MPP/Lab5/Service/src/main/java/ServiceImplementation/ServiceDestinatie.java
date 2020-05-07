package ServiceImplementation;




import ProjectModels.Destinatie;
import ProjectRepository.DestinatieRepository;
import ServiceInterface.IServiceDestinatie;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.time.LocalDateTime;
import java.util.List;

public class ServiceDestinatie implements IServiceDestinatie  {

    private DestinatieRepository rep;

    public ServiceDestinatie(DestinatieRepository rep) {
        this.rep = rep;
    }

    public synchronized int getIdDestinatie(String destinatie, LocalDateTime data) throws RemoteException {
        return rep.getIdDestinatie(destinatie, data);
    }

    public synchronized List<Destinatie> returnLista() throws RemoteException  {
        return rep.returnList();
    }

    public synchronized Destinatie getDestinatie(int id) throws RemoteException
    {
        return rep.getDestinatie(id);
    }

    public  synchronized void update(Destinatie dest) throws RemoteException
    {
        rep.update(dest);
    }
}
