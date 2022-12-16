import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom";
import { getMovie } from "../Actions/movie";

const Movie = () => {
    const { id } = useParams();

    const [movie, setMovie] = useState({
        title: "",
        description: "",
        director: "",
        cast: "",
        type: "",
        duration: 0,
        releaseDate: ""
    });

    useEffect(() => {
        getMovie(id)
            .then(response => {
                setMovie(response.data);
                console.log(response.data);
            })
            .catch(e => {
                console.log(e);
            });
    }, []);

    return (
        <div>
            {movie ? (
                <div className="edit-form">
                    <h4>Movie</h4>
                    <form>
                        <div className="form-group">
                            <label htmlFor="title">Title</label>
                            <input
                                type="text"
                                className="form-control"
                                id="title"
                                value={movie.title}
                                name="title"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="description">Description</label>
                            <input
                                type="text"
                                className="form-control"
                                id="description"
                                value={movie.description}
                                name="description"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="director">Director</label>
                            <input
                                type="text"
                                className="form-control"
                                id="director"
                                value={movie.director}
                                name="director"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="cast">Cast</label>
                            <input
                                type="text"
                                className="form-control"
                                id="cast"
                                value={movie.cast}
                                name="cast"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="type">Type</label>
                            <input
                                type="text"
                                className="form-control"
                                id="type"
                                value={movie.type}
                                name="type"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="duration">Duration</label>
                            <input
                                type="text"
                                className="form-control"
                                id="duration"
                                value={movie.duration}
                                name="duration"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="releaseDate">Release Date</label>
                            <input
                                type="text"
                                className="form-control"
                                id="releaseDate"
                                value={movie.releaseDate}
                                name="releaseDate"
                            />
                        </div>
                    </form>

                    <Link to={"/movies/" + movie.id} className="badge badge-warning">
                        Edit
                    </Link>
                    <br />
                    <Link to={"/movies"} className="badge badge-success">
                        Back to Movies
                    </Link>
                    
                </div>
            ) : (
                <div>
                    <br />
                    <p>Please click on a Movie...</p>
                </div>
            )}
        </div>
    );
};

export default Movie;
