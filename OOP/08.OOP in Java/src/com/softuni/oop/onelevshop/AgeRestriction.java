package com.softuni.oop.onelevshop;

public enum AgeRestriction {
    NONE, TEENAGER, ADULT;

    static public boolean isMember(String name) {
        AgeRestriction[] values = AgeRestriction.values();
        for (AgeRestriction restriction : values)
            if (restriction.name().equals(name))
                return true;
        return false;
    }
}
