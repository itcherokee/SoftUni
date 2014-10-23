package com.softuni.oop.geometry;

import java.util.ArrayList;

public abstract class Shape {
    private ArrayList<Point> vertices;

    protected Shape(Point vertex) {
        this.vertices = new ArrayList<Point>();
        if (vertex == null) {
            throw new NullPointerException("Invalid vortex - cannot be null.");
        }

        this.addVertex(vertex);
    }

    protected void addVertex(Point point) {
        if (point != null) {
            this.vertices.add(point);
        }
    }

    public Point getVertex(int position) {
        return this.vertices.get(position);
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append("Vertices: ");
        for (int i = 0; i < this.vertices.size(); i++) {
            output.append(String.format("(%s)", this.vertices.get(i)));
            if (i < this.vertices.size()-1){
                output.append(", ");
            }
        }

        return output.toString();
    }
}
