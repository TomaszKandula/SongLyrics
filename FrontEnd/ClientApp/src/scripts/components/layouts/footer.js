import React, { Component } from "react";

export class Footer extends Component
{

    render()
    {

        return (
            <footer className="page-footer grey lighten-4">
                <div className="container">

                    <div className="row">

                        <div className="col l6 s12">
                            <h5 className="grey-text">Song Lyrics</h5>
                            <p className="grey-text">Find the lyrics of your favourite song!</p>
                        </div>

                        <div className="col l4 offset-l2 s12">
                            <h5 className="grey-text">Find us on</h5>
                            <ul>
                                <li><a className="grey-text" href="https://linkedin.com" target="_blank" rel="noopener noreferrer">LinkedIn</a></li>
                                <li><a className="grey-text" href="https://instagram.com" target="_blank" rel="noopener noreferrer">Instagram</a></li>
                                <li><a className="grey-text" href="https://twitter.com" target="_blank" rel="noopener noreferrer">Twitter</a></li>
                                <li><a className="grey-text" href="https://facebook.com" target="_blank" rel="noopener noreferrer">Facebook</a></li>
                            </ul>
                        </div>

                    </div>

                </div>

                <div className="footer-copyright grey lighten-3">
                    <div className="container">
                        <span className="grey-text darken-4">The source code is available at <a href="https://github.com/TomaszKandula/SongLyrics" target="_blank" rel="noopener noreferrer">GitHub</a>.</span>
                    </div>
                </div>

            </footer>
        );

    }

}
