package ProjectModels;

import java.io.Serializable;
import java.time.LocalDate;
import java.time.LocalDateTime;

public class Rezervare implements Serializable {
    private int idDestinatie;
    private int Locuri_rezervate;
    private String nume;

    public Rezervare(int idDestinatie, int locuri_rezervate, String nume) {
        this.idDestinatie = idDestinatie;
        Locuri_rezervate = locuri_rezervate;
        this.nume = nume;
    }

    @Override
    public String toString() {
        return "Rezervare{" +
                "idDestinatie=" + idDestinatie +
                ", Locuri_rezervate=" + Locuri_rezervate +
                ", nume='" + nume + '\'' +
                '}';
    }

    public int getIdDestinatie() {
        return idDestinatie;
    }

    public void setIdDestinatie(int idDestinatie) {
        this.idDestinatie = idDestinatie;
    }

    public int getLocuri_rezervate() {
        return Locuri_rezervate;
    }

    public void setLocuri_rezervate(int locuri_rezervate) {
        Locuri_rezervate = locuri_rezervate;
    }

    public String getNume() {
        return nume;
    }
    public void setNume(String nume) {
        this.nume = nume;
    }
}





