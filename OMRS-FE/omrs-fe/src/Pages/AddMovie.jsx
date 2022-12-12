import React, { useState, useEffect } from "react";
//import { Link } from "react-router-dom";
import { addMovie } from "../Actions/movie";

const AddMovie = () => {
    const [movie, setMovie] = useState({
        title: "",
        description: "",
        director: "",
        cast: "",
        type: "",
        duration: "",
        releaseDate: ""
    });

    const [submitted, setSubmitted] = useState(false);

    const handleInputChange = event => {
        const { name, value } = event.target;
        setMovie({ ...movie, [name]: value });
    };

    const saveMovie = () => {
        var data = {
            title: movie.title,
            description: movie.description,
            director: movie.director,
            cast: movie.cast,
            type: movie.type,
            duration: movie.duration,
            releaseDate: movie.releaseDate
        };

        addMovie(data)
            .then(response => {
                setMovie({
                    title: response.data.title,
                    description: response.data.description,
                    director: response.data.director,
                    cast: response.data.cast,
                    type: response.data.type,
                    duration: response.data.duration,
                    releaseDate: response.data.releaseDate
                });
                setSubmitted(true);
                console.log(response.data);
            })
            .catch(e => {
                console.log(e);
            });
    };

    const newMovie = () => {
        setMovie({
            title: "",
            description: "",
            director: "",
            cast: "",
            type: "",
            duration: "",
            releaseDate: ""
        });
        setSubmitted(false);
    };

    return (
        <div className="submit-form">
            {submitted ? (
                <div>
                    <h4>You submitted successfully!</h4>
                    <button className="btn btn-success" onClick={newMovie}>
                        Add
                    </button>
                </div>
            ) : (
                <div>
                    <div className="form-group">
                        <label htmlFor="title">Title</label>
                        <input
                            type="text"
                            className="form-control"
                            id="title"
                            required
                            value={movie.title}
                            onChange={handleInputChange}
                            name="title"
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="description">Description</label>
                        <input
                            type="text"
                            className="form-control"
                            id="description"
                            required
                            value={movie.description}
                            onChange={handleInputChange}
                            name="description"
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="director">Director</label>
                        <input
                            type="text"
                            className="form-control"
                            id="director"
                            required
                            value={movie.director}
                            onChange={handleInputChange}
                            name="director"
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="cast">Cast</label>
                        <input
                            type="text"
                            className="form-control"
                            id="cast"
                            required
                            value={movie.cast}
                            onChange={handleInputChange}
                            name="cast"
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="type">Type</label>
                        <input
                            type="text"
                            className="form-control"
                            id="type"
                            required
                            value={movie.type}
                            onChange={handleInputChange}
                            name="type"
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="duration">Duration</label>
                        <input
                            type="text"
                            className="form-control"
                            id="duration"
                            required
                            value={movie.duration}
                            onChange={handleInputChange}
                            name="duration"
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="releaseDate">Release Date</label>
                        <input
                            type="text"
                            className="form-control"
                            id="releaseDate"
                            required
                            value={movie.releaseDate}
                            onChange={handleInputChange}
                            name="releaseDate"
                        />
                    </div>

                    <button onClick={saveMovie} className="btn btn-success">
                        Submit
                    </button>
                </div>
            )}
        </div>
    );
};

export default AddMovie;