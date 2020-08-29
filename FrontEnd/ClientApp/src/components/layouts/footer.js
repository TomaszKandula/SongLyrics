import React, { Component } from "react";

export class Footer extends Component
{

    render()
    {

        return (
            <footer class="page-footer grey lighten-5">
                <div class="container">

                    <div class="row">

                        <div class="col l6 s12">
                            <h5 class="grey-text">Song Lyrics</h5>
                            <p class="grey-text">Find the lyrics of your favourite song!</p>
                        </div>

                        <div class="col l4 offset-l2 s12">
                            <h5 class="grey-text">Find us on</h5>
                            <ul>
                                <li><a class="grey-text" href="https://linkedin.com" target="_blank">LinkedIn</a></li>
                                <li><a class="grey-text" href="https://instagram.com" target="_blank">Instagram</a></li>
                                <li><a class="grey-text" href="https://twitter.com" target="_blank">Twitter</a></li>
                                <li><a class="grey-text" href="https://facebook.com" target="_blank">Facebook</a></li>
                            </ul>
                        </div>

                    </div>

                </div>

                <div class="footer-copyright grey lighten-4">
                    <div class="container">
                        <span class="grey-text darken-4">The source code is available at <a href="https://github.com/TomaszKandula/SongLyrics" target="_blank">GitHub</a>.</span>
                    </div>
                </div>

            </footer>
        );

    }

}
