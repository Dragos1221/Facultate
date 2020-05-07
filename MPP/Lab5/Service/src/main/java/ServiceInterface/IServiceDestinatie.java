package ServiceInterface;


import ProjectModels.Destinatie;
import ProjectRepository.DestinatieRepository;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.time.LocalDateTime;
import java.util.List;

public interface IServiceDestinatie extends Remote {
    public int getIdDestinatie(String destinatie, LocalDateTime data) throws RemoteException;
    public List<Destinatie> returnLista() throws RemoteException;
    public Destinatie getDestinatie(int id) throws RemoteException;
    public void update(Destinatie dest) throws RemoteException;
}
