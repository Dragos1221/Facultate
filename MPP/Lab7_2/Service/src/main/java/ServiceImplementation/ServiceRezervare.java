package ServiceImplementation;



import ProjectModels.Rezervare;
import ProjectRepository.RezervareRepository;
import ServiceInterface.IServiceRezervare;


import java.util.List;

public class ServiceRezervare implements IServiceRezervare {

    private RezervareRepository rep;

    public ServiceRezervare(RezervareRepository rep) {
        this.rep = rep;
    }

    public synchronized List<Rezervare> getList(int idDestinatie)
    {
        return rep.getList(idDestinatie);
    }
    public synchronized boolean save(Rezervare rez)
    {
       return  rep.save(rez);
    }
}


