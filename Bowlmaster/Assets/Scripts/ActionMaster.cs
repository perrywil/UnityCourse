using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster { // this class is for test purposes and we do not need it to inherit from MonoBehavior

    public enum Action {Tidy, Reset, EndTurn, EndGame};

    public Action Bowl(int pins) {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("invalid pin count!");
        }

        if (pins == 10)
        {
            return Action.EndTurn;
        }
        // other behaviur here

        throw new UnityException("Not sure what action to return!");
    }
}
