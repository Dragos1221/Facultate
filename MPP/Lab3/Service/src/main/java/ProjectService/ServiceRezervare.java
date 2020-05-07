package ProjectService;



import Interfete.IServiceRezervare;
import ProjectModel.Rezervare;
import ProjectRepository.RezervareRepository;

import java.util.List;

public class ServiceRezervare implements IServiceRezervare {
    private RezervareRepository rep;

    public ServiceRezervare(RezervareRepository rep) {
        this.rep = rep;
    }

    public List<Rezervare> getList(int idDestinatie)
    {
        return rep.getList(idDestinatie);
    }
    public boolean save(Rezervare rez)
    {
       return  rep.save(rez);
    }
}


