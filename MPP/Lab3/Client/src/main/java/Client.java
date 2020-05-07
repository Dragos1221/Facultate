import Interfete.IMicTest;
import ProjectService.MicTest;

public class Client {
    private static int defaultChatPort=55555;
    private static String defaultServer="localhost";

    public static void main(String[] args) {
        IMicTest test = new MicTest();


    }
}
