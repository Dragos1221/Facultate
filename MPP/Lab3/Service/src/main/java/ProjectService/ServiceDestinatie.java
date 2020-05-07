package ProjectService;



import Interfete.IServiceDestinatie;
import ProjectModel.Destinatie;
import ProjectRepository.DestinatieRepository;

import java.time.LocalDateTime;
import java.util.List;

public class ServiceDestinatie implements IServiceDestinatie {

    private DestinatieRepository rep;

    public ServiceDestinatie(DestinatieRepository rep) {
        this.rep = rep;
    }

    public int getIdDestinatie(String destinatie, LocalDateTime data) {
        return rep.getIdDestinatie(destinatie, data);
    }

    public List<Destinatie> returnLista() {
        return rep.returnList();
    }

    public Destinatie getDestinatie(int id)
    {
        return rep.getDestinatie(id);
    }

    public void update(Destinatie dest)
    {
        rep.update(dest);
    }
}
