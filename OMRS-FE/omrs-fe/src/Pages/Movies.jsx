import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { getMovies } from "../Actions/movie";

const Movies = () => {
    const [movies, setMovies] = useState([]);
    
    useEffect(() => {
        getMovies()
            .then(response => {
                setMovies(response.data);
                console.log(response.data);
            })
            .catch(e => {
                console.log(e);
            });
    }, []);

    return (
        <div className="list row">
            {movies.map((movie, index) => (
                <div className="col-md-4" key={index}>
                    <div className="card mb-3">
                        <div className="card-body">
                            <h5 className="card-title">{movie.title}</h5>
                            <p className="card-text">
                                {movie.description}
                            </p>
                            <Link to={"/movies/" + movie.id} className="btn btn-primary">
                                View
                            </Link>
                        </div>
                    </div>
                </div>
            ))}
        </div>
    );
};

export default Movies;