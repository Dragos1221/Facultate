package Interfete;

import ProjectModel.Destinatie;
import ProjectRepository.DestinatieRepository;

import java.time.LocalDateTime;
import java.util.List;

public interface IServiceDestinatie {
    public int getIdDestinatie(String destinatie, LocalDateTime data);
    public List<Destinatie> returnLista();
    public Destinatie getDestinatie(int id);
    public void update(Destinatie dest);
}
