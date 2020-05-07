package ServiceImplementation;



import ProjectModels.Rezervare;
import ProjectRepository.RezervareRepository;
import ServiceInterface.IServiceRezervare;


import java.rmi.RemoteException;
import java.util.List;

public class ServiceRezervare implements IServiceRezervare {

    private RezervareRepository rep;

    public ServiceRezervare(RezervareRepository rep) {
        this.rep = rep;
    }

    public synchronized List<Rezervare> getList(int idDestinatie) throws RemoteException
    {
        return rep.getList(idDestinatie);
    }
    public synchronized boolean save(Rezervare rez) throws RemoteException
    {
       return  rep.save(rez);
    }
}


