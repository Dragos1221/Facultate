package ProjectModels;

import java.io.Serializable;
import java.time.LocalDateTime;

public class Destinatie implements Serializable {
    private int id;
    private LocalDateTime local;
    private int LocuriDisponibile;
    private int LocuriOcupate;
    private String Destinatie;

    public Destinatie(int id, LocalDateTime local, int locuriDisponibile, int locuriOcupate, String destinatie) {
        this.id = id;
        this.local = local;
        LocuriDisponibile = locuriDisponibile;
        LocuriOcupate = locuriOcupate;
        Destinatie = destinatie;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public LocalDateTime getLocal() {
        return local;
    }

    public void setLocal(LocalDateTime local) {
        this.local = local;
    }

    public int getLocuriDisponibile() {
        return LocuriDisponibile;
    }

    public void setLocuriDisponibile(int locuriDisponibile) {
        LocuriDisponibile = locuriDisponibile;
    }

    public int getLocuriOcupate() {
        return LocuriOcupate;
    }

    public void setLocuriOcupate(int locuriOcupate) {
        LocuriOcupate = locuriOcupate;
    }

    public String getDestinatie() {
        return Destinatie;
    }

    public void setDestinatie(String destinatie) {
        Destinatie = destinatie;
    }
}

