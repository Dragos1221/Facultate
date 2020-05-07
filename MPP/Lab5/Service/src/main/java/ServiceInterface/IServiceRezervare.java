package ServiceInterface;


import ProjectModels.Rezervare;
import ProjectRepository.RezervareRepository;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;

public interface  IServiceRezervare extends Remote {
    public List<Rezervare> getList(int idDestinatie) throws RemoteException;
    public boolean save(Rezervare rez) throws RemoteException;
}
