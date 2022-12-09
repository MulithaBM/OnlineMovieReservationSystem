const API = "http://localhost:7172/api/movie";

export const getMovies = async () => {
    try
    {
        const response = await fetch(API, {
            method: "GET",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            }
        });

        return await response.json();
    }
    catch (err)
    {
        console.log(err);
    }
};

export const getMovie = async (id) => {
    try
    {
        const response = await fetch(`${API}/${id}`, {
            method: "GET",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            }
        });

        return await response.json();
    }
    catch (err)
    {
        console.log(err);
    }
};

export const addMovie = async (movie) => {
    try
    {
        const response = await fetch(API, {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(movie)
        });

        return await response.json();
    }
    catch (err)
    {
        console.log(err);
    }
};

export const deleteMovie = async (id) => {
    try
    {
        const response = await fetch(`${API}/${id}`, {
            method: "DELETE",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            }
        });

        return await response.json();
    }
    catch (err)
    {
        console.log(err);
    }
};
