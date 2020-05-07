package ProjectService;


import Interfete.IServiceOficii;
import ProjectModel.Oficiu;
import ProjectRepository.OfficeRepository;

public class ServiceOficii implements IServiceOficii {
    private OfficeRepository rep;

    public ServiceOficii(OfficeRepository rep) {
        this.rep = rep;
    }

    public boolean logIn(Oficiu of){
        return rep.logIn(of);
    }
}
