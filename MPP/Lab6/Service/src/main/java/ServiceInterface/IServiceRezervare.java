package ServiceInterface;


import ProjectModels.Rezervare;
import ProjectRepository.RezervareRepository;

import java.util.List;

public interface IServiceRezervare {
    public List<Rezervare> getList(int idDestinatie);
    public boolean save(Rezervare rez);
}
