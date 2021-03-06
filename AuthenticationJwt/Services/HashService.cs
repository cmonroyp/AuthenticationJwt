﻿using AuthenticationJwt.Hash;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AuthenticationJwt.Services
{
    public class HashService
    {
        //una Sal es un valor aleatorio que se anexa al texto plano al cual se le applica la funcion hash, la sal se debe guardar en la Bd.
        public HashResult Hash(string input)
        {
            // Genera una sal aleatoria
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Hash(input, salt);
        }

        public HashResult Hash(string input, byte[] salt)
        {
            // deriva una subllave de 256 bits (usa HMACSHA1 con 10,000 iteraciones)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
          password: input,
          salt: salt,
          prf: KeyDerivationPrf.HMACSHA1,
          iterationCount: 10000,
          numBytesRequested: 256 / 8));

            return new HashResult()
            {
                Hash = hashed,
                Salt = salt
            };
        }
    }
}
