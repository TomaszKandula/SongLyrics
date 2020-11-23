import React, { Component } from "react";

export class Footer extends Component
{

    render()
    {

        return (
            <footer className="page-footer deep-purple lighten-1">

                <div className="container">

                    <div className="row">

                        <div className="col l6 s12">
                            <h5 className="deep-purple-text text-lighten-5">Song Lyrics</h5>
                            <p className="deep-purple-text text-lighten-5">Find the lyrics of your favourite song!</p>
                        </div>

                        <div className="col l4 offset-l2 s12">
                            <h5 className="deep-purple-text text-lighten-5">Find us on</h5>
                            <ul>
                                <li><a className="deep-purple-text text-lighten-5" href="https://linkedin.com" target="_blank" rel="noopener noreferrer">LinkedIn</a></li>
                                <li><a className="deep-purple-text text-lighten-5" href="https://instagram.com" target="_blank" rel="noopener noreferrer">Instagram</a></li>
                                <li><a className="deep-purple-text text-lighten-5" href="https://twitter.com" target="_blank" rel="noopener noreferrer">Twitter</a></li>
                                <li><a className="deep-purple-text text-lighten-5" href="https://facebook.com" target="_blank" rel="noopener noreferrer">Facebook</a></li>
                            </ul>
                        </div>

                    </div>

                </div>

                <div className="footer-copyright deep-purple darken-1">
                    <div className="container">
                        <span className="deep-purple-text text-lighten-3">The source code is available at <a href="https://github.com/TomaszKandula/SongLyrics" target="_blank" rel="noopener noreferrer">GitHub</a>.</span>
                    </div>
                </div>

            </footer>
        );

    }

}
