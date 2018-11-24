using UnityEngine;

public static class AngleUtil {
    public static Vector3 ConvertAngle(Vector3 vector){
        return new Vector3(
            vector.x > 180 ? vector.x - 360 : vector.x,
            vector.y > 180 ? vector.x - 360 : vector.y,
            vector.z > 180 ? vector.z - 360 : vector.z
        );
    }
    
}
